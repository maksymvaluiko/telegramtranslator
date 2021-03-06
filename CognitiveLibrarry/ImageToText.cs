﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace CognitiveServices
{
    public class ImageToText
    {
        const string telegramKeyToken = "1208156096:AAGEDobyvScgd3L-SbSVrCtb3TgufscYFcA";

        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }

        // Retuns array of words.
        public static async Task<string[]> RecognizePrintedTextUrl(ComputerVisionClient client, string imageUrl)
        {
            // Perform OCR on image
            OcrResult remoteOcrResult = await client.RecognizePrintedTextAsync(true, imageUrl);
            string[] result = null;

            foreach (var remoteRegion in remoteOcrResult.Regions)
            {
                foreach (var line in remoteRegion.Lines)
                {
                    result = line.Words.Select(w => w.Text).ToArray();
                }
            }

            return result;
        }

        public static async Task ResponceToUser()
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}
