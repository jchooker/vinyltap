namespace VinylTap.Extensions
{
    public static class RandomNonce
    {
        public static string FormNonce() {
            string fullNonce = FormChunk(8) + "-" + FormChunk(4) + "-" + FormChunk(4) + "-" + FormChunk(4) + "-" + FormChunk(12);
            Console.WriteLine(fullNonce);
            return fullNonce;
        }

        private static string FormChunk(int chunkLength) {
            string chunk = "";
            for (int i=0; i < chunkLength; i++) {
                int[] minMax = WhichASCIIRange();
                Random rand = new Random();
                int randNum = rand.Next(minMax[0], minMax[1] + 1);
                if (minMax[0] == 0) {
                    chunk += randNum.ToString();
                } else {
                    chunk += Convert.ToChar(randNum);
                }
            }
                
            return chunk;
        }

        private static int[] WhichASCIIRange() {
            int[] minMax = new int[2];
            Random random = new Random();
            int type = random.Next(0, 3);
            switch (type) {
                case 0: //alphaNumType is number 0-9
                    minMax[0] = 0;
                    minMax[1] = 9;
                    break;
                case 1: //alphaNumType is uppercase letter A-Z
                    minMax[0] = 65;
                    minMax[1] = 90;
                    break;
                case 2: //alphaNumType is lowercase letter a-z
                    minMax[0] = 97;
                    minMax[1] = 122;
                    break;
            }
            return minMax;
        }
    }
}