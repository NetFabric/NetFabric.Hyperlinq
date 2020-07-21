## Int32RangeSelectToArray

### Source
[Int32RangeSelectToArray.cs](../LinqBenchmarks/Int32/Range/Int32RangeSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  86.51 ns | 0.632 ns | 0.591 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 Linq |     0 |   100 | 278.87 ns | 2.200 ns | 1.950 ns |  3.22 |    0.04 | 0.2446 |     - |     - |     512 B |
|           LinqFaster |     0 |   100 | 286.77 ns | 3.274 ns | 2.903 ns |  3.31 |    0.04 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 554.68 ns | 4.885 ns | 4.569 ns |  6.41 |    0.06 | 0.7839 |     - |     - |    1640 B |
| StructLinq_IFunction |     0 |   100 | 358.25 ns | 2.705 ns | 2.398 ns |  4.14 |    0.04 | 0.7839 |     - |     - |    1640 B |
|            Hyperlinq |     0 |   100 | 261.36 ns | 1.888 ns | 1.674 ns |  3.02 |    0.03 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Pool |     0 |   100 | 302.25 ns | 2.488 ns | 2.206 ns |  3.49 |    0.03 | 0.0267 |     - |     - |      56 B |
