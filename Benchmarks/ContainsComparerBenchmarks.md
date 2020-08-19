## ContainsComparerBenchmarks

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
|                         Method |           Categories | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 | 578.0 ns | 3.85 ns | 3.21 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_Array |                Array |   100 | 220.4 ns | 1.10 ns | 0.98 ns |  0.38 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 | 219.0 ns | 0.87 ns | 0.77 ns |  0.38 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 | 221.0 ns | 1.41 ns | 1.25 ns |  0.38 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 757.8 ns | 6.29 ns | 5.89 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 228.7 ns | 0.97 ns | 0.86 ns |  0.30 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 755.9 ns | 2.41 ns | 2.13 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 203.7 ns | 0.65 ns | 0.58 ns |  0.27 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 766.3 ns | 5.03 ns | 4.20 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|           Hyperlinq_List_Value |           List_Value |   100 | 380.6 ns | 1.32 ns | 1.10 ns |  0.50 |      - |     - |     - |         - |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 661.8 ns | 5.44 ns | 5.09 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 612.3 ns | 2.05 ns | 1.82 ns |  0.93 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 547.9 ns | 2.85 ns | 2.52 ns |  1.00 | 0.0114 |     - |     - |      24 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 548.6 ns | 2.69 ns | 2.52 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 554.0 ns | 1.83 ns | 1.71 ns |  1.00 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 | 383.0 ns | 1.24 ns | 1.03 ns |  0.69 |      - |     - |     - |         - |
