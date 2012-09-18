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
    class DBHelper : Android.Database.Sqlite.SQLiteOpenHelper
    {
        private const string DbName = "GolfScore";
        private const int DbVersion = 1;

        public DBHelper(Context context) : base(context, DbName, null, DbVersion)
        {

        }

        
        public override void OnCreate(Android.Database.Sqlite.SQLiteDatabase db)
        {
            db.ExecSQL(@"CREATE TABLE IF NOT EXISTS GolfScore (GolfID INTEGER PRIMARY KEY AUTOINCREMENT," +
                "ScoreDate varchar(30) NOT NULL, ScoreNumber NOT NULL, Rating double NOT NULL, Slope int not null)");
        }

        public override void OnUpgrade(Android.Database.Sqlite.SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS GolfScore");

            OnCreate(db);
        }


    }
}