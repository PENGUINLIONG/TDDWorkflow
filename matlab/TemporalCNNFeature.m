% =========================================================================
%
% Func: TemporalCNNFeature()
% Params:
%   [string] $vid_name: The name of video file.
%   [object] $net: The NN object.
%   [integer] $NUM_HEIGHT: The height of target video to be transformed.
%   [integer] $NUM_WIDTH: The width of target video to be transformed.
%
% =========================================================================

function [FCNNFeature_c4, FCNNFeature_c3] = TemporalCNNFeature(envPath, vid_prefix, net, NUM_HEIGHT, NUM_WIDTH)
% The number of frames to be traced.
L = 10;
% Input video
filelist =dir([vid_prefix,'*_x*.jpg']);
video = zeros(NUM_HEIGHT,NUM_WIDTH,L*2,length(filelist));
for i = 1: length(filelist)
    flow_x = imread(sprintf('%s_%04d.jpg',[vid_prefix,'_flow_x'],i));
    flow_y = imread(sprintf('%s_%04d.jpg',[vid_prefix,'_flow_y'],i));
    video(:,:,1,i) = imresize(flow_x,[NUM_HEIGHT,NUM_WIDTH],'bilinear');
    video(:,:,2,i) = imresize(flow_y,[NUM_HEIGHT,NUM_WIDTH],'bilinear');
end

% Transform image sequence to video matrix of Height x Width x Direction
%   Channel x Frame.
for i = 1:L-1
    tmp = cat(4, video(:,:,(i-1)*2+1:i*2,2:end),video(:,:,(i-1)*2+1:i*2,end));
    video(:,:,i*2+1:i*2+2,:) = tmp;
end

% Load flow mean data, which helps normalizing.
d  = load([envPath, 'flow_mean.mat']);
FLOW_MEAN = d.image_mean;
FLOW_MEAN = imresize(FLOW_MEAN,[NUM_HEIGHT,NUM_WIDTH]);

% Make batch arguments.
batch_size = 40;
num_images = size(video,4);
num_batches = ceil(num_images/batch_size);

FCNNFeature_c4 = [];
FCNNFeature_c3 = [];

% Process flow video in batches.
for bb = 1 : num_batches
    % Divide frames into batches.
    range = 1 + batch_size*(bb-1): min(num_images,batch_size*bb);
    images = zeros(NUM_WIDTH, NUM_HEIGHT, L*2, batch_size, 'single');
    tmp = video(:,:,:,range);
    
    % For each frame in this batch.
    for ii = 1 : size(tmp,4)
        img = single(tmp(:,:,:,ii));
        images(:,:,:,ii) = permute(img -FLOW_MEAN,[2,1,3]);
    end
    
    % Look for blobs in frames.
    net.blobs('data').set_data(images);
    net.forward_prefilled();
    feature_c4 = permute(net.blobs('conv4').get_data(),[2,1,3,4]);
    feature_c3 = permute(net.blobs('conv3').get_data(),[2,1,3,4]);
    
    % Zero initialize return value.
    if isempty(FCNNFeature_c4)
        FCNNFeature_c4 = zeros(size(feature_c4,1), size(feature_c4,2), size(feature_c4,3), num_images, 'single');
        FCNNFeature_c3 = zeros(size(feature_c3,1), size(feature_c3,2), size(feature_c3,3), num_images, 'single');
    end
    
    % Return value.
    FCNNFeature_c4(:,:,:,range) = feature_c4(:,:,:,mod(range-1,batch_size)+1);
    FCNNFeature_c3(:,:,:,range) = feature_c3(:,:,:,mod(range-1,batch_size)+1);   
end

end