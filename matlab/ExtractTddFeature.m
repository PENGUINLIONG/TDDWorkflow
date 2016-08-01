function ExtractTddFeature(envPath, inputDir, inputFileNameWithoutExtension, outputDir, scale, gpuId)

IDT = import_idt([inputDir, '\Result\', inputFileNameWithoutExtension, '_idt.bin'], 15);
info = IDT.info;
tra = IDT.tra;

sizes = [8,8; 11.4286,11.4286; 16,16; 22.8571,24;32,34.2587];
sizes_vid = [480,640; 340,454; 240,320; 170,227; 120,160];

% :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

% Spatial TDD
display('Extract spatial TDD...');

% Load neural networks and set up GPU for future calculation.
model_def_file = [ envPath, 'ModelProto\spatial_net_scale_', num2str(scale), '.prototxt'];
model_file = [envPath, 'spatial_v2.caffemodel'];
caffe.reset_all();
caffe.set_mode_gpu();
caffe.set_device(gpuId);
net = caffe.Net(model_def_file, model_file, 'test');

% Get spatial feature maps.
[feature_conv4, feature_conv5] = SpatialCNNFeature(envPath, [inputDir, '\', inputFileNameWithoutExtension, '.avi'], net, sizes_vid(scale,1), sizes_vid(scale,2));
% Reset 
if max(info(1,:)) > size(feature_conv4,4)
    ind =  info(1,:) <= size(feature_conv4,4);
    info = info(:,ind);
    tra = tra(:,ind);
end

% Normalize feature maps.
[feature_conv_normalize_1, feature_conv_normalize_2] = FeatureMapNormalization(feature_conv4);
tdd_feature_spatial_conv4_norm_1 = TDD(info, tra, feature_conv_normalize_1, sizes(scale,1), sizes(scale,2), 1);
tdd_feature_spatial_conv4_norm_2 = TDD(info, tra, feature_conv_normalize_2, sizes(scale,1), sizes(scale,2), 1);

save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_s_c4_n1.mat'], 'tdd_feature_spatial_conv4_norm_1');
save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_s_c4_n2.mat'], 'tdd_feature_spatial_conv4_norm_2');

[feature_conv_normalize_1, feature_conv_normalize_2] = FeatureMapNormalization(feature_conv5);
tdd_feature_spatial_conv5_norm_1 = TDD(info, tra, feature_conv_normalize_1, sizes(scale,1), sizes(scale,2), 1);
tdd_feature_spatial_conv5_norm_2 = TDD(info, tra, feature_conv_normalize_2, sizes(scale,1), sizes(scale,2), 1);

save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_s_c5_n1.mat'], 'tdd_feature_spatial_conv5_norm_1');
save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_s_c5_n2.mat'], 'tdd_feature_spatial_conv5_norm_2');

% :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

% Temporal TDD
display('Extract temporal TDD...');

% Load neural networks and set up GPU for future calculation.
model_def_file = [ envPath, 'ModelProto\temporal_net_scale_', num2str(scale),'.prototxt'];
model_file = [envPath, 'temporal_v2.caffemodel'];
caffe.reset_all();
caffe.set_mode_gpu();
caffe.set_device(gpuId);
net = caffe.Net(model_def_file, model_file, 'test');

% Get temporal feature maps.
[feature_conv3, feature_conv4] = TemporalCNNFeature(envPath, [inputDir, '\Result\', inputFileNameWithoutExtension], net, sizes_vid(scale,1), sizes_vid(scale,2));
if max(info(1,:)) > size(feature_conv4,4)
    ind =  info(1,:) <= size(feature_conv4,4);
    info = info(:,ind);
    tra = tra(:,ind);
end

% Normalize feature maps.
[feature_conv_normalize_1, feature_conv_normalize_2] = FeatureMapNormalization(feature_conv3);
tdd_feature_temporal_conv3_norm_1 = TDD(info, tra, feature_conv_normalize_1, sizes(scale,1), sizes(scale,2), 1);
tdd_feature_temporal_conv3_norm_2 = TDD(info, tra, feature_conv_normalize_2, sizes(scale,1), sizes(scale,2), 1);

save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_t_c3_n1.mat'], 'tdd_feature_temporal_conv3_norm_1');
save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_t_c3_n2.mat'], 'tdd_feature_temporal_conv3_norm_2');

[feature_conv_normalize_1, feature_conv_normalize_2] = FeatureMapNormalization(feature_conv4);
tdd_feature_temporal_conv4_norm_1 = TDD(info, tra, feature_conv_normalize_1, sizes(scale,1), sizes(scale,2), 1);
tdd_feature_temporal_conv4_norm_2 = TDD(info, tra, feature_conv_normalize_2, sizes(scale,1), sizes(scale,2), 1);

save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_t_c4_n1.mat'], 'tdd_feature_temporal_conv4_norm_1');
save([outputDir, '\Result\', inputFileNameWithoutExtension, '_scale', num2str(scale), '_t_c4_n2.mat'], 'tdd_feature_temporal_conv4_norm_2');

caffe.reset_all();

end