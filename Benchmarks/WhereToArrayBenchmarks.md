## WhereToArrayBenchmarks

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
|                         Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   442.3 ns | 3.20 ns | 2.84 ns |  1.00 | 0.3443 |     - |     - |     720 B |
|                Hyperlinq_Array |                Array |   100 |   513.9 ns | 3.28 ns | 3.07 ns |  1.16 | 0.1068 |     - |     - |     224 B |
|                 Hyperlinq_Span |                Array |   100 |   509.1 ns | 2.18 ns | 2.04 ns |  1.15 | 0.1068 |     - |     - |     224 B |
|               Hyperlinq_Memory |                Array |   100 |   510.4 ns | 3.97 ns | 3.32 ns |  1.15 | 0.1068 |     - |     - |     224 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,105.8 ns | 7.29 ns | 6.46 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   520.7 ns | 3.90 ns | 3.65 ns |  0.47 | 0.1068 |     - |     - |     224 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,104.1 ns | 7.17 ns | 6.71 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   525.1 ns | 3.31 ns | 3.10 ns |  0.48 | 0.1068 |     - |     - |     224 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 1,111.1 ns | 6.03 ns | 5.64 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   786.9 ns | 5.34 ns | 5.00 ns |  0.71 | 0.1068 |     - |     - |     224 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 |   929.5 ns | 5.61 ns | 5.25 ns |  1.00 | 0.3672 |     - |     - |     768 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 1,008.7 ns | 5.52 ns | 5.17 ns |  1.09 | 0.1259 |     - |     - |     264 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   834.9 ns | 3.85 ns | 3.41 ns |  1.00 | 0.3595 |     - |     - |     752 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   932.9 ns | 6.70 ns | 5.23 ns |  1.12 | 0.1183 |     - |     - |     248 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   840.9 ns | 4.48 ns | 4.19 ns |  1.00 | 0.3595 |     - |     - |     752 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   788.0 ns | 4.81 ns | 4.50 ns |  0.94 | 0.1068 |     - |     - |     224 B |
