using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns.Builder
{
    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();
        public ConcreteBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _product = new Product();
        }
        public Product GetProduct()
        {
            Product result = _product;

            Reset();

            return result;
        }

        // All production steps work with the same product instance.
        public void BuildPartA()
        {
            _product.Add("PartA1");
        }

        public void BuildPartB()
        {
            _product.Add("PartB1");
        }

        public void BuildPartC()
        {
            _product.Add("PartC1");
        }
    }
}
