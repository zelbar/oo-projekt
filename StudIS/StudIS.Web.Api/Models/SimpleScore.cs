using StudIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Api.Models
{
    public class SimpleScore
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public string ComponentName { get; set; }
        public float ComponentMinToPass { get; set; }
        public float ComponentMax { get; set; }


        public SimpleScore(Score score)
        {
            Id = score.Id;
            Value = score.Value;
            ComponentName = score.Component.Name;
            ComponentMinToPass = score.Component.MinimumPointsToPass;
            ComponentMax = score.Component.MaximumPoints;

        }
        public SimpleScore()
        {

        }

    }
}