## WhereFirstBenchmarks

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
|                     Linq_Array |                Array |   100 | 591.1 ns | 5.41 ns | 5.06 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_Array |                Array |   100 | 208.4 ns | 0.95 ns | 0.89 ns |  0.35 | 0.0305 |     - |     - |      64 B |
|                 Hyperlinq_Span |                Array |   100 | 187.1 ns | 1.10 ns | 0.98 ns |  0.32 | 0.0305 |     - |     - |      64 B |
|               Hyperlinq_Memory |                Array |   100 | 187.8 ns | 1.09 ns | 0.91 ns |  0.32 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 778.9 ns | 3.37 ns | 2.99 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 250.3 ns | 1.38 ns | 1.22 ns |  0.32 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 800.7 ns | 2.70 ns | 2.53 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 239.3 ns | 1.16 ns | 1.03 ns |  0.30 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 804.4 ns | 3.22 ns | 2.86 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           Hyperlinq_List_Value |           List_Value |   100 | 371.5 ns | 1.99 ns | 1.86 ns |  0.46 | 0.0305 |     - |     - |      64 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 667.3 ns | 3.68 ns | 3.26 ns |  1.00 | 0.0496 |     - |     - |     104 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 624.9 ns | 3.23 ns | 3.02 ns |  0.94 | 0.0496 |     - |     - |     104 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 558.8 ns | 3.62 ns | 3.21 ns |  1.00 | 0.0420 |     - |     - |      88 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 529.7 ns | 2.95 ns | 2.30 ns |  0.95 | 0.0420 |     - |     - |      88 B |
|                                |                      |       |          |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 560.0 ns | 3.84 ns | 3.59 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 | 346.3 ns | 2.35 ns | 2.09 ns |  0.62 | 0.0305 |     - |     - |      64 B |
