# ObjectEquality v1.0.5
A open-source library to compare whether two object are same

## How to use it?

### Check Value-Type object
Example:
```
var a = 1;
var b = 2;

var objectEquality = new ObjectEquality();
objectEquality.IsEqual(a,b);
```
### Check Array object
Example:
```
var a = new int[]{1,2,3};
var b = new int[]{1,2,3};
var c = new int[]{1,2,4};

var objectEquality = new ObjectEquality();
objectEquality.IsEqual(a,b); //true
objectEquality.IsEqual(a,c); //false
```

### Check Array object(Loose mode)

You can set the <code>ArrayEqualityMode</code> of <code>ObjectEqualityOptions</code> as Loose to enable the loose mode

Example
```
var a = new int[] { 1, 2, 3 };
var b = new int[] { 2, 1, 3 };
var c = new int[] { 1, 1, 3 };

ObjectEqualityOptions.Current.ArrayEqualityMode = ArrayEqualityMode.Loose;
var objectEquality = new ObjectEquality();
objectEquality.IsEqual(a,b); //true
objectEquality.IsEqual(a,c); //false

```

### Check two dimension array

Example
```

var arrayA = new int[2, 3] { { 1, 1, 1 }, { 2, 2, 2 } };
var arrayB = new int[2, 3] { { 1, 1, 1 }, { 2, 2, 2 } };
var arrayC = new int[2, 3] { { 1, 1, 2 }, { 2, 2, 2 } };

arrayA.IsEqual(arrayB); //true
arrayA.IsEqual(arrayC); //false

```

> We only support strict mode for two dimension array. 



### Check Simple Class object

```
public class SimpleClass
{
    public int Id { get; set; }

    public string Name { get; set; }
}

var a = new SimpleClass
{
    Id = 1,
    Name = "A"
};

var b = new SimpleClass
{
    Id = 1,
    Name = "A"
};

var objectEquality = new ObjectEquality();
objectEquality.IsEqual(a,b); //true

```
