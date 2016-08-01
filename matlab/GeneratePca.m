function GeneratePca(inputFilePaths, outputFileName, outputFileDir)

feature = [];

for i = 1:size(inputFilePaths, 1)
    input = struct2cell(load(char(inputFilePaths(i,1))));
    feature = [feature, input{1}];
end

[U,mu,vars] = pca(feature);
PCA = struct('U', U, 'mu', mu, 'vars', vars);

save([outputFileDir, '\', outputFileName, '.mat'], 'PCA');

end