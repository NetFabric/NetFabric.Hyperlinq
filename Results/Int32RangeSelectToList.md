## Int32RangeSelectToList

### Source
[Int32RangeSelectToList.cs](../LinqBenchmarks/Int32/Range/Int32RangeSelectToList.cs)

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
|               Method | Start | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 | 307.6 ns | 3.64 ns | 3.23 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|          ForeachLoop |     0 |   100 | 722.1 ns | 5.37 ns | 4.76 ns |  2.35 |    0.02 | 0.5922 |     - |     - |    1240 B |
|                 Linq |     0 |   100 | 360.6 ns | 1.17 ns | 0.91 ns |  1.17 |    0.01 | 0.2599 |     - |     - |     544 B |
|           LinqFaster |     0 |   100 | 372.5 ns | 2.29 ns | 2.03 ns |  1.21 |    0.01 | 0.6232 |     - |     - |    1304 B |
|           StructLinq |     0 |   100 | 482.8 ns | 3.87 ns | 3.62 ns |  1.57 |    0.02 | 0.5808 |     - |     - |    1216 B |
| StructLinq_IFunction |     0 |   100 | 332.7 ns | 2.08 ns | 1.95 ns |  1.08 |    0.01 | 0.5813 |     - |     - |    1216 B |
|            Hyperlinq |     0 |   100 | 292.1 ns | 1.88 ns | 1.67 ns |  0.95 |    0.01 | 0.2446 |     - |     - |     512 B |
