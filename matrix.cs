using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slave {
  class matrix {
    protected double[] mass;
    protected int row, col;
    protected uint ID;
    protected static uint _ID = 0;

    public matrix() {
      ID = ++_ID;
      row = 0;
      col = 0;   

      mass = null;
      Console.WriteLine("");
    }

    public matrix(int rnc){
      if(rnc == 0){
        ID = ++_ID;
        this.row = 0;
        this.col = 0;
        mass = null;
        Console.WriteLine("matrix " + ID + ": created");
      }
      else {
        ID = ++_ID;
        this.row = rnc;
        this.col = rnc;
        mass = new double[rnc*rnc
        ];
        for (int i = 0; i < row * col; i++) {
          mass[i] = 0;
        }
        Console.WriteLine("matrix " + ID + ": created");
      }
    }
    public matrix(int r, int c){
      if(r == 0 || c == 0){
          ID = ++_ID;
          this.row = 0;
          this.col = 0;
          mass = null;
          }
          else {
          ID = ++_ID;
          this.row = r;
          this.col = c;
        
          mass = new double[r*c];
          for (int i = 0; i < row* col; i++){
              mass[i] = 0;
            }
          } 
          Console.WriteLine("matrix " + ID + ": created" );
      
      }
    public matrix(int r, int c, double[] m){
      if(r != 0 && c != 0){
        this.row = r;
        this.col = c;
        mass = new double[r*c];
        for (int i = 0; i < r*c; i++){
            mass[i] = m[i];
        }
      }
      Console.WriteLine("matrix "+ ID + ": created");
    }
    public matrix(int r, int c, Func<uint, uint, double> F){
      if(r == 0|| c == 0){
        ID = ++_ID;
        this.row = 0;
        this.col = 0;

        mass =null;
        Console.WriteLine("Matrix "+ ID +": created");
      }
      else{
        ID= ++_ID;
        this.row = r;
        this.col = c;

        mass = new double[r*c];
        for (uint i = 0; i < r; i++){
            for(uint j =0; j < c; j++)
              mass[i * c +j] = F(i,j);
        }
      }
    }
    public matrix(matrix obj){
      ID = ++_ID;
      this.row = obj.row;
      this.col = obj.col;
      mass = new double[row*col];
      for (int i = 0; i < row*col; i++){
          mass[i] = obj.mass[i];
      }
    }
    ~matrix(){
        Console.WriteLine("matrix "+ID+": deleted");
      _ID = _ID-1;
    }
    public override string ToString()
      {
        string text ="";
        if(this.row == 0 || this.col == 0){
        text = " ";
              
        }
        else {
          for(int i = 0; i < this.row; i++){
            for(int j = 0; j < this.col; j++){
              text +=string.Format("{0:F2}", mass[i * this.col + j]) +"\t";
               }
            text += "\n";
            }
          }
            return text;
        }

      public bool checkSum(matrix obj){
        return ((row == obj.row)&&(col == obj.col));
      }

      public bool checkMul(matrix obj){
        return row == obj.col;
      }

      public double max(){
        if(!this.IsNull()){
          double max = Double.MinValue;
          for(uint i=0; i<row*col; i++)
            max = mass[i] > max ? mass[i] : max;
          return max;
        }else
          return 0;
      }

      public double min(){
        if(!this.IsNull()){
          double min = Double.MaxValue;
          for(uint i=0; i<this.row*this.col; i++)
            min = this.mass[i] < min ? this.mass[i] : min;
          return min;
        }else
          return 0;
      }
      public bool IsNull(){
        return this.mass == null ? true : false;
      }
      public static matrix operator +(matrix fobj, matrix sobj){
        if(fobj.checkSum(sobj) && !fobj.IsNull() && !sobj.IsNull()){
          matrix tmp = new matrix(fobj);
          for(int i=0; i < fobj.row * fobj.col; i++)
            tmp.mass[i] = fobj.mass[i] + sobj.mass[i];
          return tmp;
        }
        else
          throw new ArgumentException("Err: " + "obj "+ fobj.ID+ " and obj " + sobj.ID + " cannot be summed");
      }
      public static matrix operator-(matrix fobj, matrix sobj){
        if(fobj.checkSum(sobj) && !fobj.IsNull() && !sobj.IsNull()){
          matrix tmp = new matrix(fobj);
          for(int i=0; i < fobj.row * fobj.col; i++)
            tmp.mass[i] = fobj.mass[i] - sobj.mass[i];
          return tmp;
        }
        else
          throw new ArgumentException("Err: " + "obj "+ fobj.ID+ " and obj " + sobj.ID + " cannot be deducted");
      }
      public static matrix operator*(matrix fobj, matrix sobj){
        if(fobj.checkMul(sobj) && !fobj.IsNull() && !sobj.IsNull()){
          matrix tmp = new matrix(fobj.row, sobj.col);

          for(int i=0; i< fobj.row * sobj.col; i++)
            tmp.mass[i] = 0;

          for(int i=0; i< fobj.row; i++)
            for(int j=0; j< sobj.col; j++)
              for(int k =0; k <fobj.col; k++)
                tmp.mass[i * sobj.col + j] += (fobj.mass[i * fobj.col + k] * sobj.mass[k* sobj.col + j]);
          return tmp;
        }else
          throw new ArgumentException("Err: " + "obj "+ fobj.ID + " and obj "+ sobj.ID + " cannot be multiplied");
      }
      public static matrix operator*(matrix obj, double item){
        if(!obj.IsNull()){
          matrix tmp = new matrix(obj);
          for(int i=0; i < obj.row * obj.col; i++)
            tmp.mass[i] *= item;
          return tmp;
        }
        else
          throw new ArgumentException("Err: " + "obj "+ obj.ID + " cannot be multiplied");
      }

      public double this[uint r, uint c]{
        get{
          if(r < this.row && c < this.col)
            return this.mass[r*this.col + c];
          else
            throw new ArgumentException( "Obj " + ID + ": Out of range");
        }
        set{
          if(r < this.row && c < this.col)
            mass[r* this.col + c] = value;
          else
            throw new ArgumentException("Obj "+ ID + ": Out of range");
        }
      }
    }
  }
