% =========================================================================
%
% Func: FeatureMapNormalization()
% Params:
%   [string] $vid_name: The name of video file.
%   [object] $net: The NN object.
%   [integer] $NUM_HEIGHT: The height of target video to be transformed.
%   [integer] $NUM_WIDTH: The width of target video to be transformed.
%
% =========================================================================

function [FCNNFeature_c5, FCNNFeature_c4] = SpatialCNNFeature(envPath, vid_name, net, NUM_HEIGHT, NUM_WIDTH)

% Input video
vidObj = VideoReader(vid_name);

% Read video into memory, creating a 4D (Height x Width x Color Channel x
%    Frame) matrix $video.
duration = vidObj.NumberOfFrame;
video = zeros(NUM_HEIGHT, NUM_WIDTH, 3, duration,'single');
for i = 1 : duration
    tmp = read(vidObj,i);
    video(:,:,:,i) = imresize(tmp, [NUM_HEIGHT, NUM_WIDTH], 'bilinear');
end

% Load VGG mean data, which helps normalizing.
d = load([envPath, 'VGG_mean.mat']);
IMAGE_MEAN = d.image_mean;
IMAGE_MEAN = imresize(IMAGE_MEAN,[NUM_HEIGHT,NUM_WIDTH]);
video = video(:,:,[3,2,1],:);
video = bsxfun(@minus,video,IMAGE_MEAN);
video = permute(video,[2,1,3,4]);

% Make batch arguments.
batch_size = 40;
num_images = size(video,4);
num_batches = ceil(num_images/batch_size);

FCNNFeature_c5 = [];
FCNNFeature_c4 = [];

% Process video in batches.
images = zeros(NUM_WIDTH, NUM_HEIGHT, 3, batch_size, 'single');
for bb = 1 : num_batches
    % Divide frames into batches.
    range = 1 + batch_size*(bb-1): min(num_images,batch_size*bb);
    tmp = video(:,:,:,range);
    images(:,:,:,1:size(tmp,4)) = tmp;
    
    % Look for blobs in frames.
    net.blobs('data').set_data(images);
    net.forward_prefilled();
    % Exchange width and height.
    feature_c5 = permute(net.blobs('conv5').get_data(),[2,1,3,4]);
    feature_c4 = permute(net.blobs('conv4').get_data(),[2,1,3,4]);
    
    % Zero initialize return value.
    if isempty(FCNNFeature_c5)
        FCNNFeature_c5 = zeros(size(feature_c5,1), size(feature_c5,2), size(feature_c5,3), num_images, 'single');
        FCNNFeature_c4 = zeros(size(feature_c4,1), size(feature_c4,2), size(feature_c4,3), num_images, 'single');
    end
    
    % Return value.
    FCNNFeature_c5(:,:,:,range) = feature_c5(:,:,:,mod(range-1,batch_size)+1);
    FCNNFeature_c4(:,:,:,range) = feature_c4(:,:,:,mod(range-1,batch_size)+1);
end

end