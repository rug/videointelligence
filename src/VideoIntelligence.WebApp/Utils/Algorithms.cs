using VideoIntelligence.WebApp.Model;

namespace VideoIntelligence.WebApp.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// Calculate the difference between 2 strings using the Levenshtein distance algorithm
        /// </summary>
        /// <param name="source1">First string</param>
        /// <param name="source2">Second string</param>
        /// <returns></returns>
        public static int LevenshteinDistance(string source1, string source2) //O(n*m)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(source1, nameof(source1));
            ArgumentException.ThrowIfNullOrWhiteSpace(source1, nameof(source2));

            var source1Length = source1.Length;
            var source2Length = source2.Length;

            var matrix = new int[source1Length + 1, source2Length + 1];

            // First calculation, if one entry is empty return full length
            if (source1Length == 0)
                return source2Length;

            if (source2Length == 0)
                return source1Length;

            // Initialization of matrix with row size source1Length and columns size source2Length
            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            return matrix[source1Length, source2Length];
        }

        /// <summary>
        /// Calculates the Levenshtein distance as a percentage relative to the length of the longer string.
        /// </summary>
        public static double LevenshteinAsPercentage(string s, string t)
        {
            int distance = LevenshteinDistance(s, t);
            int maxLength = Math.Max(s.Length, t.Length);

            // Avoid division by zero if both strings are empty.
            if (maxLength == 0)
                return 0.0;

            double percentage = ((double)distance / maxLength) * 100;
            return percentage;
        }

        public static List<ShotDetail> GetShots(ArtifactOcrResult artifactOcrs
            , VideoFramesResponse videoFrames
            , List<KeyFrameInsightInstanceWithThumbnailUrl> listKeyFrames)
        {
            ArgumentNullException.ThrowIfNull(artifactOcrs, nameof(artifactOcrs));
            ArgumentNullException.ThrowIfNull(videoFrames, nameof(videoFrames));

            List<ShotDetail> OcrList = new List<ShotDetail>();

            foreach (var item in listKeyFrames)
            {
                
                OcrList.Add(new ShotDetail()
                {
                    EndTime =  item.End,
                    StartTime = item.Start,
                    FilePath = item.ThumbnailUrl
                });
            }


            
            ArtifactOcrResultItem? prevOcr = null;

            foreach (ArtifactOcrResultItem item in artifactOcrs.Results)
            {
                if (prevOcr != null)
                {
                    int contentLenght = item.Ocr.Content.Length;
                    int prevContentLenght = prevOcr.Ocr.Content.Length;
                    
                    if (LevenshteinAsPercentage(item.Ocr.ContentWithNoWhiteSpace, prevOcr.Ocr.ContentWithNoWhiteSpace) > 80)
                    {
                        
                        var frame = videoFrames.Results.FirstOrDefault(f => f.FrameIndex == item.FrameIndex);
                        if (frame != null)
                        {
                            //ShotDetail? ocrDetails = OcrList.FirstOrDefault(e => e.StartTime == frame.StartTime || e.EndTime == frame.EndTime);
                            //if (ocrDetails == null)
                            //{
                            //    ocrDetails = new ShotDetail() {
                            //        Ocr = item.Ocr.Content,
                            //        StartTime = frame.StartTime,
                            //        EndTime = frame.EndTime,
                            //        FilePath = frame.FilePath
                            //    };
                            //    OcrList.Add(ocrDetails);
                            //}
                            //else
                            //{
                            //    ocrDetails.Ocr = item.Ocr.Content;
                            //}
                           
                        }
                        
                        
                    }
                }

                prevOcr = item;
            }


            

            return OcrList;
        }

    }
}
