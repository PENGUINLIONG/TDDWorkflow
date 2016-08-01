function ExtractFisherVector(pcaPath1, pcaPath2, gmmPath1, gmmPath2, inputDir, inputFileNameWithoutExtensionNorm1, inputFileNameWithoutExtensionNorm2, outputDir)

% Number of feature held.
num = 256;
% GMM row count. The 1st dimension of final output.
dim1 = 64;

%%% Work for norm1.

coding1 = [];

% Principle Component Analysis.
load(pcaPath1);
% Gaussian Mixture Model
load(gmmPath1);

% Load input file.
input1 = struct2cell(load([inputDir, '\', inputFileNameWithoutExtensionNorm1, '.mat']));
feature1 = (input1{1});

if ~isempty(feature1)
    % Equals to: $feature - $PCA.mu (binary)
    feature1 = bsxfun(@minus,feature1,PCA.mu);
    % Reduce dimension.
    feature1 = PCA.U(:,1:dim1)' * feature1;
    % Equals to: $feature ./ sqrt($PCA.vars(1:dim1)) (binary)
    feature1 = bsxfun(@rdivide,feature1,sqrt(PCA.vars(1:dim1)));
    coding1 = vl_fisher(feature1,GMM.means,GMM.covariances,GMM.priors);
else
    % $feature is empty, skip this feature set.
    coding1 = [];
end

%%% Work for norm2.

coding2 = [];

% Principle Component Analysis.
load(pcaPath2);
% Gaussian Mixture Model
load(gmmPath2);

% Load input file.
input2 = struct2cell(load([inputDir, '\', inputFileNameWithoutExtensionNorm2, '.mat']));
feature2 = (input2{1});

if ~isempty(feature2)
    % Equals to: $feature - $PCA.mu (binary)
    feature2 = bsxfun(@minus,feature2,PCA.mu);
    % Reduce dimension.
    feature2 = PCA.U(:,1:dim1)' * feature2;
    % Equals to: $feature ./ sqrt($PCA.vars(1:dim1)) (binary)
    feature2 = bsxfun(@rdivide,feature2,sqrt(PCA.vars(1:dim1)));
    coding2 = vl_fisher(feature2,GMM.means,GMM.covariances,GMM.priors);
else
    % $feature is empty, skip this feature set.
    coding2 = [];
end

fisher_vector = [coding1; coding2];

% Save $coding to file.
save([outputDir, '\', inputFileNameWithoutExtensionNorm1(1:end - 3), '_fv.mat'], 'fisher_vector');

end