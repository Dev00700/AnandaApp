using Dapper;
using System;
using System.Text;
using MyApp.Models.Common;
namespace MyApp.Models.Common
{
    public static class CommonFunction
    {
        public static void Printparameter(DynamicParameters pram,String logtype)
        {
            var log = new StringBuilder();
            foreach (var param in pram.ParameterNames)
            {
                var value = pram.Get<dynamic>(param);
                log.Append($"@{param} = '{value}',");
            }
            Logger.WriteLog(log.ToString(), logtype);
        }

    }
}
