## Int32RangeToList

### Source
[Int32RangeToList.cs](../LinqBenchmarks/Int32/Range/Int32RangeToList.cs)

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
|      Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 | 280.52 ns | 3.151 ns | 2.631 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
| ForeachLoop |     0 |   100 | 683.77 ns | 5.361 ns | 5.015 ns |  2.44 |    0.04 | 0.5922 |     - |     - |    1240 B |
|        Linq |     0 |   100 | 193.51 ns | 0.985 ns | 0.874 ns |  0.69 |    0.01 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 122.45 ns | 1.549 ns | 1.373 ns |  0.44 |    0.01 | 0.4206 |     - |     - |     880 B |
|  StructLinq |     0 |   100 | 296.46 ns | 2.038 ns | 1.701 ns |  1.06 |    0.01 | 0.5774 |     - |     - |    1208 B |
|   Hyperlinq |     0 |   100 |  98.57 ns | 0.647 ns | 0.574 ns |  0.35 |    0.00 | 0.2333 |     - |     - |     488 B |
