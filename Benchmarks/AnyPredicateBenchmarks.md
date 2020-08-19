## AnyPredicateBenchmarks

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
|                     Linq_Array |                Array |   100 | 16.706 ns | 0.1266 ns | 0.1184 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_Array |                Array |   100 |  4.205 ns | 0.0383 ns | 0.0358 ns |  0.25 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |  4.557 ns | 0.0457 ns | 0.0356 ns |  0.27 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |  5.255 ns | 0.0777 ns | 0.0727 ns |  0.31 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 17.203 ns | 0.1109 ns | 0.0926 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 16.220 ns | 0.1125 ns | 0.1052 ns |  0.94 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 18.035 ns | 0.0799 ns | 0.0708 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 18.975 ns | 0.0946 ns | 0.0790 ns |  1.05 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 17.259 ns | 0.0736 ns | 0.0688 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|           Hyperlinq_List_Value |           List_Value |   100 |  8.608 ns | 0.0604 ns | 0.0565 ns |  0.50 |      - |     - |     - |         - |
|                                |                      |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 20.580 ns | 0.1129 ns | 0.1001 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 20.078 ns | 0.2227 ns | 0.1974 ns |  0.98 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 13.918 ns | 0.0975 ns | 0.0912 ns |  1.00 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 16.384 ns | 0.1293 ns | 0.1210 ns |  1.18 | 0.0115 |     - |     - |      24 B |
|                                |                      |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 14.149 ns | 0.1359 ns | 0.1271 ns |  1.00 | 0.0115 |     - |     - |      24 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |  8.620 ns | 0.0519 ns | 0.0434 ns |  0.61 |      - |     - |     - |         - |
