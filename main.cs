using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slave {
  class program {
    static void Main(string[] args) {
      int count = 3;      
      matrix a = new matrix(count);
      matrix b = new matrix(count);
      
      Random rnd = new Random();
      for(uint i=0; i< count; i++){
        for(uint j=0; j < count; j++){
          a[i,j] = rnd.Next()%50;
          b[i,j] = rnd.Next()%50;
              
        }
      }
      matrix c = a + b;
      matrix d = a - b;
      matrix e = a * b; 
      Console.WriteLine(a.ToString());
      Console.WriteLine(b.ToString()); 
      
        Console.WriteLine("__________________");
      Console.WriteLine(c.ToString());
      Console.WriteLine(d.ToString()); 
      Console.WriteLine(e.ToString()); 
    }
  }
}
