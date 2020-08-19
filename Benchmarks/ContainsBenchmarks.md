## ContainsBenchmarks

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
|                         Method |           Categories | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |  32.896 ns | 0.3115 ns | 0.2914 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                Array |   100 |  24.836 ns | 0.2279 ns | 0.2020 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |  70.864 ns | 0.5405 ns | 0.5056 ns |  2.15 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |  77.899 ns | 0.4409 ns | 0.3909 ns |  2.37 |    0.02 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 614.482 ns | 5.0560 ns | 4.7294 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 319.469 ns | 1.9142 ns | 1.6969 ns |  0.52 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                |                      |       |            |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 |   4.314 ns | 0.0314 ns | 0.0263 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 222.021 ns | 1.1515 ns | 1.0771 ns | 51.49 |    0.36 | 0.0153 |     - |     - |      32 B |
|                                |                      |       |            |           |           |       |         |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 |   4.930 ns | 0.0502 ns | 0.0470 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |           List_Value |   100 |   5.205 ns | 0.0643 ns | 0.0570 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 453.766 ns | 2.5269 ns | 2.2400 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 564.928 ns | 4.2493 ns | 3.7669 ns |  1.25 |    0.01 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |            |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   4.088 ns | 0.0413 ns | 0.0366 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |  16.507 ns | 0.1479 ns | 0.1311 ns |  4.04 |    0.05 | 0.0115 |     - |     - |      24 B |
|                                |                      |       |            |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   4.837 ns | 0.0286 ns | 0.0268 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   5.388 ns | 0.0336 ns | 0.0298 ns |  1.11 |    0.01 |      - |     - |     - |         - |
