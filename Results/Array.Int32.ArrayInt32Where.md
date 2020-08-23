## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  76.44 ns | 0.632 ns | 0.591 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  75.95 ns | 0.651 ns | 0.609 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 478.90 ns | 3.392 ns | 3.173 ns |  6.27 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 319.94 ns | 2.547 ns | 2.258 ns |  4.19 |    0.04 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 388.08 ns | 1.442 ns | 1.278 ns |  5.08 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 | 313.25 ns | 1.998 ns | 1.869 ns |  4.10 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 164.87 ns | 1.581 ns | 1.479 ns |  2.16 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 340.93 ns | 1.053 ns | 0.933 ns |  4.46 |    0.04 |      - |     - |     - |         - |
