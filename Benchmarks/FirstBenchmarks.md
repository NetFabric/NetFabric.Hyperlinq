## FirstBenchmarks

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
|                     Linq_Array |                Array |   100 | 27.200 ns | 0.2711 ns | 0.2536 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                Array |   100 |  3.965 ns | 0.0161 ns | 0.0143 ns |  0.15 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |  3.998 ns | 0.0452 ns | 0.0422 ns |  0.15 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |  5.526 ns | 0.0539 ns | 0.0504 ns |  0.20 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 22.621 ns | 0.1140 ns | 0.1010 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 16.100 ns | 0.0575 ns | 0.0538 ns |  0.71 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 22.339 ns | 0.1351 ns | 0.1197 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 17.870 ns | 0.1240 ns | 0.1100 ns |  0.80 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 11.681 ns | 0.0491 ns | 0.0435 ns |  1.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |           List_Value |   100 |  7.245 ns | 0.0249 ns | 0.0221 ns |  0.62 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 26.636 ns | 0.2052 ns | 0.1714 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 19.676 ns | 0.1083 ns | 0.0904 ns |  0.74 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 19.837 ns | 0.1290 ns | 0.1144 ns |  1.00 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 15.558 ns | 0.0809 ns | 0.0757 ns |  0.78 | 0.0115 |     - |     - |      24 B |
|                                |                      |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 11.474 ns | 0.1159 ns | 0.1027 ns |  1.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |       List_Reference |   100 |  7.140 ns | 0.0310 ns | 0.0290 ns |  0.62 |      - |     - |     - |         - |
