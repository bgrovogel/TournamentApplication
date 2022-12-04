using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Make the CreatePrize method acutally save to the database
        /// <summary>
        /// Saves a new prize to the database.
        /// </summary>
        /// <param name="model">The prize information.</param>
        /// <returns>The prize information, including the unique identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PlaceNumber", model.PlaceNumber);
                parameters.Add("@PlaceName", model.PlaceName);
                parameters.Add("@PrizeAmount", model.PrizeAmount);
                parameters.Add("@PrizePercentage", model.PrizePercentage);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");

                return model;
            }
        }
    }
}
