using BertMlNet.MachineLearning.DataModel;
using Microsoft.ML;
using System.Collections.Generic;

namespace BertMlNet.MachineLearning
{
    public class Trainer
    {
        private readonly MLContext _mlContext;

        public Trainer()
        {
            _mlContext = new MLContext(11);
        }

        public ITransformer BuidAndTrain(string bertModelPath, bool useGpu)
        {
            var pipeline = _mlContext.Transforms.ApplyOnnxModel(modelFile: bertModelPath,
                                            outputColumnNames: new[] { "unstack:1",
                                                                       "unstack:0",
                                                                       "unique_ids:0" },
                                            inputColumnNames: new[] {"unique_ids_raw_output___9:0",
                                                                      "segment_ids:0",
                                                                      "input_mask:0",
                                                                      "input_ids:0" },
                                            gpuDeviceId: useGpu ? 0 : (int?)null);

            return pipeline.Fit(_mlContext.Data.LoadFromEnumerable(new List<BertInput>()));
        }
    }
}
//Severity	Code	Description	Project	File	Line	Suppression State
//Error CS1061	'TransformsCatalog' does not contain a definition for 'ApplyOnnxModel' and no accessible extension method 'ApplyOnnxModel' accepting a first argument of type 'TransformsCatalog' could be found (are you missing a using directive or an assembly reference?)	