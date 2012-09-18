using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Leitor
{
    class dbCommands
    {
        private DBHelper dbHelp;
        public dbCommands(Context context)
        {
            dbHelp = new DBHelper(context);
            dbHelp.OnCreate(dbHelp.WritableDatabase);
        }

        public IList<Score> GetAllScores()
        {
            Android.Database.ICursor golfCursor = dbHelp.ReadableDatabase.Query("GolfScore", null, null, null, null, null, null, null);
            var scores = new List<Score>();
            while (golfCursor.MoveToNext())
            {
                Score scr = MapScores(golfCursor);
                scores.Add(scr);
            }
            return scores;
        }

        public long AddScore(int ScoreNumber, DateTime ScoreDate, double rating, double slope)
        {
            var values = new ContentValues();
            values.Put("ScoreNumber", ScoreNumber);
            values.Put("ScoreDate", ScoreDate.ToString());
            values.Put("Rating", rating);
            values.Put("Slope", slope);

            return dbHelp.WritableDatabase.Insert("GolfScore", null, values);
        }

        public void DeleteScore(int ScoreID)
        {
            string[] vals = new string[1];
            vals[0] = ScoreID.ToString();

            dbHelp.WritableDatabase.Delete("GolfScore", "ScoreId=?", vals);
        }
        private Score MapScores(Android.Database.ICursor cursor)
        {
            Score scr = new Score();
            scr.ScoreID = cursor.GetInt(0);
            scr.ScoreDate = cursor.GetString(1);
            scr.ScoreNumber = cursor.GetInt(2);
            scr.Rating = cursor.GetDouble(3);
            scr.Slope = cursor.GetInt(4);
            return (scr);
        }
    }
}