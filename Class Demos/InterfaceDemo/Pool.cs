namespace InterfaceDemo;

public class Pool : IShape{

    private string poolName = "";
    public double length, width, depth;

    public string PoolName{
        get{return this.PoolName;}
        set{this.poolName = value;}
    }

    // Define a constructor
    public Pool(double length, double width, double depth){
        this.length = length;
        this.depth = depth;
        this.width = width;
        
    }

    public double CalculateArea(){
        return this.length * this.width;
    }

    public double CalculatePerimeter(){
        return (this.length * 2) + (this.width * 2);
    }

    public double CalculateVolume(){
        return this.length * this.width * this.depth;
    }

}