## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   245.1 ns |  0.74 ns |  0.69 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   225.2 ns |  0.78 ns |  0.69 ns |  0.92 |    0.00 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   243.8 ns |  0.92 ns |  0.77 ns |  0.99 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |   236.7 ns |  0.59 ns |  0.53 ns |  0.97 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |   214.3 ns |  0.62 ns |  0.52 ns |  0.87 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,094.7 ns |  7.58 ns |  6.33 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,038.8 ns |  3.74 ns |  3.50 ns |  0.95 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   590.2 ns |  4.13 ns |  3.86 ns |  0.54 |    0.00 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,080.1 ns |  4.55 ns |  4.03 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,040.5 ns |  4.03 ns |  3.36 ns |  0.96 |    0.00 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   244.6 ns |  1.72 ns |  1.34 ns |  0.23 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   476.1 ns |  2.13 ns |  1.99 ns |  1.00 |    0.00 | 0.2289 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   436.6 ns |  0.61 ns |  0.51 ns |  0.92 |    0.00 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   432.8 ns |  1.51 ns |  1.26 ns |  0.91 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   906.4 ns |  2.49 ns |  2.21 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   774.4 ns |  1.35 ns |  1.20 ns |  0.85 |    0.00 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   921.8 ns |  1.61 ns |  1.42 ns |  1.02 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   849.8 ns |  1.65 ns |  1.46 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   816.3 ns |  2.27 ns |  2.01 ns |  0.96 |    0.00 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   575.5 ns |  3.08 ns |  2.73 ns |  0.68 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   399.4 ns |  1.23 ns |  1.09 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   781.4 ns |  2.56 ns |  2.40 ns |  1.96 |    0.01 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   375.9 ns |  1.06 ns |  0.83 ns |  0.94 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,004.5 ns | 27.12 ns | 25.37 ns |     ? |       ? | 0.8087 |     - |     - |    1712 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,280.5 ns | 15.97 ns | 14.16 ns |     ? |       ? | 0.8240 |     - |     - |    1728 B |
