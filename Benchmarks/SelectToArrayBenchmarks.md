## SelectToArrayBenchmarks

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
|                         Method |           Categories | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   221.9 ns |  0.79 ns |   0.70 ns |   222.0 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                Hyperlinq_Array |                Array |   100 |   223.3 ns |  1.12 ns |   1.00 ns |   223.4 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq_Span |                Array |   100 |   248.6 ns |  1.08 ns |   0.84 ns |   248.6 ns |  1.12 |    0.01 | 0.2027 |     - |     - |     424 B |
|               Hyperlinq_Memory |                Array |   100 |   225.1 ns |  1.24 ns |   1.16 ns |   225.3 ns |  1.01 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                |                      |       |            |          |           |            |       |         |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,103.7 ns |  7.49 ns |   7.01 ns | 1,102.5 ns |  1.00 |    0.00 | 0.5875 |     - |     - |    1232 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   588.8 ns |  2.60 ns |   2.43 ns |   588.6 ns |  0.53 |    0.00 | 0.2022 |     - |     - |     424 B |
|                                |                      |       |            |          |           |            |       |         |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,097.4 ns |  7.59 ns |   6.73 ns | 1,100.2 ns |  1.00 |    0.00 | 0.5875 |     - |     - |    1232 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   270.5 ns |  1.75 ns |   1.56 ns |   270.4 ns |  0.25 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                |                      |       |            |          |           |            |       |         |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 |   409.6 ns |  1.79 ns |   1.59 ns |   410.2 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   389.2 ns |  3.04 ns |   2.70 ns |   389.4 ns |  0.95 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                |                      |       |            |          |           |            |       |         |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 |   970.2 ns |  8.45 ns |   7.90 ns |   971.2 ns |  1.00 |    0.00 | 0.5951 |     - |     - |    1248 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 1,031.2 ns |  8.36 ns |   6.98 ns | 1,033.3 ns |  1.06 |    0.01 | 0.2213 |     - |     - |     464 B |
|                                |                      |       |            |          |           |            |       |         |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   886.8 ns |  8.90 ns |   7.89 ns |   884.7 ns |  1.00 |    0.00 | 0.5884 |     - |     - |    1232 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   764.8 ns | 36.51 ns | 107.66 ns |   726.0 ns |  0.77 |    0.03 | 0.2136 |     - |     - |     448 B |
|                                |                      |       |            |          |           |            |       |         |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   414.6 ns |  2.49 ns |   2.20 ns |   414.1 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   471.9 ns |  8.70 ns |  10.02 ns |   471.5 ns |  1.14 |    0.03 | 0.2022 |     - |     - |     424 B |
