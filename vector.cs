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
    public static vector operator -(vector fobj, vector sobj){
      if(fobj.checkSum(sobj) && !fobj.IsNull() && !sobj.IsNull()){
        vector tmp = new vector(fobj);

        for(int i=0; i < fobj.row * fobj.col; i++)
        tmp.mass[i] -=sobj.mass[i];
        return tmp;
      }
      else
        throw new ArgumentException("obj " + fobj.ID + ": Out of range" );
    }
    public static vector operator *(vector obj, double item){
      if(!obj.IsNull()){
        vector tmp = new vector(obj);
        for(int i=0; i< obj.row * obj.col; i++)
          tmp.mass[i] *= item;
        return tmp;
      }
      else
        throw new ArgumentException("Err: " + "obj" + obj.ID + " is empty");
    }
    public static matrix operator *(vector fobj, vector sobj){
      if(fobj.checkMul(sobj) && !fobj.IsNull() && !sobj.IsNull()){
        matrix tmp = new matrix(fobj.row, sobj.col);
        for(uint i=0; i< fobj.row; i++)
          for(uint j=0; j < sobj.col; j++){
            tmp[i,j] = 0;
            for(uint k=0; k < fobj.col; k++)
              tmp[i,j] += fobj[i,k] * sobj[k,j];
          }
        return tmp;
      }
      else
        throw new ArgumentException("Err: " + "obj "+ fobj.ID + " and obj "+ sobj.ID + " cannot be multiplied");
    }
    public vector transpose(){
      int tmp = col;
      col = row;
      row = tmp;
      return this;
    }
    public vector scal(double item){
      if(!IsNull()){
        for(int i=0; i < row; i++)
          mass[i] *= item;
          return this;
      }
      else 
        throw new ArgumentException("vector: " + ID + " is empty");
    }
    public vector norm(){
      if(!IsNull()){
        double md = mod();
        for(int i=0; i < row; i++)
          mass[i]/= md;
        return this;
      }
      else
        throw new ArgumentException("vector: " + ID + " is empty");
    }
    public double mod(){
      if(!IsNull()){
        double ans = 0;
        for(int i=0; i < row; i++)
          ans += mass[i]*mass[i];
        return Math.Sqrt(ans);
      }
      else
        throw new ArgumentException("vector: " + ID + " is empty");
    }
    public vector vecMult(vector fobj, vector sobj){
      if(fobj.row > 3 || sobj.row > 3) 
        throw new Exception("vector: out of size");
      else{
        vector tmp = new vector(3);
        tmp.mass[0] = (fobj.mass[1] * sobj.mass[2]) - (fobj.mass[2] * sobj.mass[1]);
        tmp.mass[1] = (fobj.mass[2] * sobj.mass[0]) - (fobj.mass[0] * sobj.mass[2]);
        tmp.mass[2] = (fobj.mass[0] * sobj.mass[1]) - (fobj.mass[1] * sobj.mass[0]);
        return tmp;
      }
    }
    public double cos(vector obj){
      return this.scalMult(obj)/(this.mod() * obj.mod());
    }
    public double sin(vector obj){
      return 1- Math.Pow(this.cos(obj),2);
    }
    public double scalMult(vector obj){
      if(this.checkSum(obj) && !this.IsNull() && !obj.IsNull()){
        double ans = 0;
        for(int i=0; i < this.row; i++)
          ans += this.mass[i] * obj.mass[i]; 
        return ans;
      }
      else 
        throw new Exception("Err: Cannot be multiplied");
    }
    public double angle(vector obj){
      return Math.Acos(this.scalMult(obj)/(this.mod() * obj.mod())) * 180 / Math.PI;
    }
    public double this[uint r]{
      get{
        if(r < this.row){
          return this.mass[r];
        }
        else 
          throw new ArgumentException("obj " + ID + ": Out of range");
      }
      set{
        if(r < this.row){
          this.mass[r] = value;
        }
        else
          throw new ArgumentException("obj " + ID + ": Out of range");
      }
    }
  }
}
