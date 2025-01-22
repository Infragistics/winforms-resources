using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MainModule {
    public class DataAccess {
        private static DataSet northWind = null;
        private static DataSet pubs = null;
        private static DataAccess da = null;

        public static DataAccess GetDataAccess() {
            if (da == null) {
                da = new DataAccess();
            }
            return da;
        }

        private DataAccess() {
            northWind = new DataSet();
            northWind.ReadXml("Northwind.xml");
            northWind.AcceptChanges();

            pubs = new DataSet();
            pubs.ReadXml("Pubs.xml");
            pubs.AcceptChanges();

        }

        public static DataSet GetDataSet(string db) {
            switch (db) {
                case "Northwind":
                    return northWind;
                case "Pubs":
                    return pubs;
            }

            return null;
        }
    }
}

