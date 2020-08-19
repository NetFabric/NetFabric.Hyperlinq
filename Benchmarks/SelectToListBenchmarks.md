## SelectToListBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |           Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   301.3 ns | 11.61 ns | 33.68 ns |   282.4 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                Hyperlinq_Array |                Array |   100 |   244.7 ns |  1.60 ns |  1.49 ns |   244.7 ns |  0.68 |    0.03 | 0.2408 |     - |     - |     504 B |
|                 Hyperlinq_Span |                Array |   100 |   290.3 ns |  1.54 ns |  1.36 ns |   290.5 ns |  0.81 |    0.05 | 0.2179 |     - |     - |     456 B |
|               Hyperlinq_Memory |                Array |   100 |   245.4 ns |  1.55 ns |  1.45 ns |   245.6 ns |  0.68 |    0.04 | 0.2408 |     - |     - |     504 B |
|                                |                      |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,092.1 ns |  7.95 ns |  7.43 ns | 1,092.2 ns |  1.00 |    0.00 | 0.6027 |     - |     - |    1264 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   588.8 ns |  5.24 ns |  4.65 ns |   589.0 ns |  0.54 |    0.01 | 0.2518 |     - |     - |     528 B |
|                                |                      |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,099.6 ns |  6.61 ns |  6.18 ns | 1,098.5 ns |  1.00 |    0.00 | 0.6027 |     - |     - |    1264 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   275.5 ns |  1.37 ns |  1.22 ns |   275.7 ns |  0.25 |    0.00 | 0.2408 |     - |     - |     504 B |
|                                |                      |       |            |          |          |            |       |         |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 |   471.8 ns |  4.03 ns |  3.77 ns |   470.7 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   455.4 ns |  2.28 ns |  2.02 ns |   455.7 ns |  0.96 |    0.01 | 0.2408 |     - |     - |     504 B |
|                                |                      |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 |   969.4 ns |  7.28 ns |  6.45 ns |   969.2 ns |  1.00 |    0.00 | 0.6104 |     - |     - |    1280 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 1,054.0 ns |  7.69 ns |  7.20 ns | 1,052.7 ns |  1.09 |    0.01 | 0.2708 |     - |     - |     568 B |
|                                |                      |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   824.4 ns |  5.56 ns |  5.20 ns |   823.3 ns |  1.00 |    0.00 | 0.6037 |     - |     - |    1264 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   581.6 ns |  3.90 ns |  3.46 ns |   582.1 ns |  0.71 |    0.01 | 0.2480 |     - |     - |     520 B |
|                                |                      |       |            |          |          |            |       |         |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   525.5 ns |  2.45 ns |  2.29 ns |   526.0 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   452.2 ns |  2.01 ns |  1.88 ns |   452.6 ns |  0.86 |    0.00 | 0.2408 |     - |     - |     504 B |
