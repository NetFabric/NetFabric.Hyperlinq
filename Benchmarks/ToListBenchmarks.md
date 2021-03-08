## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   100.49 ns |  2.012 ns |  2.066 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |   159.93 ns |  3.261 ns |  3.489 ns |  1.59 |    0.04 | 0.2179 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    89.17 ns |  1.748 ns |  1.717 ns |  0.89 |    0.02 | 0.2180 |     - |     - |     456 B |
|                      Hyperlinq_Span |                     Array |   100 |    90.08 ns |  0.663 ns |  0.620 ns |  0.90 |    0.02 | 0.2180 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |    90.22 ns |  1.441 ns |  1.277 ns |  0.90 |    0.03 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,016.43 ns | 15.081 ns | 17.367 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,022.66 ns |  7.305 ns |  6.833 ns |  1.00 |    0.02 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   590.46 ns |  7.576 ns |  6.326 ns |  0.58 |    0.01 | 0.2365 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    92.42 ns |  1.329 ns |  1.110 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,021.52 ns |  9.677 ns |  8.578 ns | 11.06 |    0.14 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   201.00 ns |  3.920 ns |  3.667 ns |  2.17 |    0.05 | 0.2370 |     - |     - |     496 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    93.78 ns |  1.895 ns |  1.773 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   276.61 ns |  3.188 ns |  2.489 ns |  2.96 |    0.08 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   685.86 ns | 11.944 ns | 17.877 ns |  7.40 |    0.28 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,524.66 ns | 20.667 ns | 18.321 ns |  1.00 |    0.00 | 0.5836 |     - |     - |    1224 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,888.11 ns | 18.310 ns | 16.232 ns |  0.75 |    0.01 | 0.5798 |     - |     - |    1216 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   795.96 ns |  9.481 ns |  8.405 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   814.38 ns |  8.311 ns |  7.774 ns |  1.02 |    0.02 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   851.90 ns |  5.129 ns |  4.283 ns |  1.07 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    91.19 ns |  1.779 ns |  1.577 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   763.47 ns |  8.963 ns |  7.485 ns |  8.37 |    0.20 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   558.52 ns |  5.640 ns |  5.276 ns |  6.13 |    0.14 | 0.2441 |     - |     - |     512 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    93.50 ns |  1.390 ns |  1.161 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   808.61 ns |  6.173 ns |  5.774 ns |  8.65 |    0.13 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   607.59 ns |  6.584 ns |  6.159 ns |  6.50 |    0.08 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,383.31 ns | 18.852 ns | 16.711 ns |  1.00 |    0.00 | 0.5836 |     - |     - |    1224 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,556.73 ns | 10.855 ns | 10.154 ns |  1.07 |    0.01 | 0.5989 |     - |     - |    1256 B |
