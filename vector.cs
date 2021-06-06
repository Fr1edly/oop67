using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slave {
  class vector : matrix {
    public vector() : base(){
      ID = _ID;
      Console.WriteLine("vector "+ ID +": created");
    }
    public vector(int r) : base(r, 1){
      ID = _ID;
      Console.WriteLine("vector "+ ID +": created");
    }
    public vector(int r, Func<int, double> F): base(r, 1){
      for(int i=0; i< r;i++)
        mass[i]=F(i);
      ID =_ID;
       Console.WriteLine("vector "+ ID +": created");
    }
    public vector(matrix obj) : base(obj){
      if(col > 1)
        throw new Exception("Err: out of size");
      Console.WriteLine("vector "+ this.ID +": copy created");
    }
    ~vector(){
      Console.WriteLine("vector " + this.ID + ": deleted");
    }

    public static vector operator +(vector fobj, vector sobj){
      if(fobj.checkSum(sobj) && !fobj.IsNull() && !sobj.IsNull()){
        vector tmp = new vector(fobj);
        for( int i=0; i < fobj.row * fobj.col; i++)
          tmp.mass[i] += sobj.mass[i];
        return tmp;
      }
      else 
      throw new ArgumentException("Err: " + "obj " + fobj.ID + " and obj "+ sobj.ID + "cannot be summed");
    }
  }
}
