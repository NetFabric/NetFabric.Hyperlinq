## WhereToListBenchmarks

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
|                         Method |           Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   397.1 ns |  2.54 ns |  2.37 ns |  1.00 | 0.3328 |     - |     - |     696 B |
|                Hyperlinq_Array |                Array |   100 |   556.6 ns |  3.02 ns |  2.83 ns |  1.40 | 0.1564 |     - |     - |     328 B |
|                 Hyperlinq_Span |                Array |   100 |   554.5 ns |  2.48 ns |  2.20 ns |  1.40 | 0.1564 |     - |     - |     328 B |
|               Hyperlinq_Memory |                Array |   100 |   568.2 ns |  4.24 ns |  3.97 ns |  1.43 | 0.1564 |     - |     - |     328 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,016.5 ns |  9.19 ns |  8.15 ns |  1.00 | 0.3471 |     - |     - |     728 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   606.2 ns |  4.13 ns |  3.86 ns |  0.60 | 0.1564 |     - |     - |     328 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,047.8 ns | 14.61 ns | 13.67 ns |  1.00 | 0.3471 |     - |     - |     728 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   637.7 ns |  3.87 ns |  3.62 ns |  0.61 | 0.1564 |     - |     - |     328 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 1,014.8 ns |  3.94 ns |  3.69 ns |  1.00 | 0.3471 |     - |     - |     728 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   862.5 ns |  4.13 ns |  3.86 ns |  0.85 | 0.1564 |     - |     - |     328 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 |   838.6 ns |  3.64 ns |  3.23 ns |  1.00 | 0.3557 |     - |     - |     744 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 1,044.8 ns |  7.95 ns |  6.64 ns |  1.25 | 0.1755 |     - |     - |     368 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   795.1 ns |  4.36 ns |  3.86 ns |  1.00 | 0.3481 |     - |     - |     728 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   971.7 ns |  4.64 ns |  4.34 ns |  1.22 | 0.1678 |     - |     - |     352 B |
|                                |                      |       |            |          |          |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   792.4 ns |  6.42 ns |  6.00 ns |  1.00 | 0.3481 |     - |     - |     728 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   823.8 ns |  6.57 ns |  5.49 ns |  1.04 | 0.1564 |     - |     - |     328 B |
