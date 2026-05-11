using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCollections
{
    public class DataContainer
    {
        string id;
        double attrD1;
        double attrD2;

        public void SetId(string v) { this.id = v; }
        public string GetId() { return this.id; }
        public void SetAttrD1(double v) { this.attrD1 = v; }
        public double GetAttrD1() { return this.attrD1; }

        public void SetAttrD2(double v) { this.attrD2 = v; }

        public double GetAttrD2()
        {
            return this.attrD2;
        }
    }
}