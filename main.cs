using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slave {
  class program {
    static void Main(string[] args) {
      int count = 3;      
      vector a = new vector(count);
      matrix c = new matrix(1,count);
      vector b = new vector(count);
      Random rnd = new Random();
      for(uint i=0; i< count; i++){
        a[i] = rnd.Next()%50;
        b[i] = rnd.Next()%50;
        c[0,i]= rnd.Next()%50;
      }
      Console.WriteLine(a.ToString());
      Console.WriteLine(c.ToString());
      a.transpose();
      matrix d = a + c;
      //Console.WriteLine(c.row);
      //Console.WriteLine(d.ToString());
      Console.WriteLine(d.ToString());
      //Console.WriteLine(cos(a,b));
      //Console.WriteLine(a[4]);
      //Console.WriteLine(a.cos(b));
      //Console.WriteLine(a.sin(b));
      //Console.WriteLine(a.scalMult(b));
      //Console.WriteLine(a.angle(b));
      //
      //Console.WriteLine(b.ToString());      
    }
  }
}
