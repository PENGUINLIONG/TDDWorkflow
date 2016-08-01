function count = GetVideoFrameCount(fileName)
vidObj = VideoReader(fileName);
count = vidObj.NumberOfFrame;
end