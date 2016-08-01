function GenerateGmm(inputFilePaths, pcaFilePath, outputFileName, outputFileDir)

feature = [];

num = 256;
dim1 = 64;

for i = 1:size(inputFilePaths, 1)
    input = struct2cell(load(char(inputFilePaths(i,1))));
    feature = [feature, input{1}];
end

load(pcaFilePath);

feature = bsxfun(@minus,feature,PCA.mu);
feature = PCA.U(:,1:dim1)' * feature;
feature = bsxfun(@rdivide,feature,sqrt(PCA.vars(1:dim1)));

[means, covariances, priors] = vl_gmm(feature, num);
GMM = struct('means', means, 'covariances', covariances, 'priors', priors);

save([outputFileDir, '\', outputFileName, '.mat'], 'GMM');

end