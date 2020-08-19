## AllBenchmarks

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
|                         Method |           Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 | 22.509 ns | 0.2534 ns | 0.2370 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_Array |                Array |   100 |  6.581 ns | 0.0696 ns | 0.0651 ns |  0.29 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |  6.609 ns | 0.0662 ns | 0.0620 ns |  0.29 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |  6.489 ns | 0.0865 ns | 0.0722 ns |  0.29 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 26.148 ns | 0.4343 ns | 0.4063 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 17.319 ns | 0.1265 ns | 0.1183 ns |  0.66 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 25.613 ns | 0.1877 ns | 0.1568 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 20.258 ns | 0.1693 ns | 0.1583 ns |  0.79 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 24.546 ns | 0.3146 ns | 0.2627 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|           Hyperlinq_List_Value |           List_Value |   100 | 12.952 ns | 0.1428 ns | 0.1266 ns |  0.53 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 27.025 ns | 0.2073 ns | 0.1838 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 26.086 ns | 0.2298 ns | 0.2150 ns |  0.96 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 19.899 ns | 0.2390 ns | 0.2236 ns |  1.00 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 21.087 ns | 0.1549 ns | 0.1373 ns |  1.06 | 0.0115 |     - |     - |      24 B |
|                                |                      |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 20.181 ns | 0.1830 ns | 0.1528 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 | 12.616 ns | 0.1348 ns | 0.1261 ns |  0.62 |      - |     - |     - |         - |
