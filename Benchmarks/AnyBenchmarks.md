## AnyBenchmarks

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
|                         Method |           Categories | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |  8.5053 ns | 0.0898 ns | 0.0840 ns |  8.5189 ns | 1.000 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                Array |   100 |  0.0070 ns | 0.0089 ns | 0.0083 ns |  0.0036 ns | 0.001 |    0.00 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |  0.2790 ns | 0.0109 ns | 0.0102 ns |  0.2776 ns | 0.033 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |  0.2779 ns | 0.0168 ns | 0.0157 ns |  0.2818 ns | 0.033 |    0.00 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |            |       |         |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 18.3228 ns | 0.1816 ns | 0.1699 ns | 18.3570 ns |  1.00 |    0.00 | 0.0115 |     - |     - |      24 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |  9.8604 ns | 0.0614 ns | 0.0544 ns |  9.8574 ns |  0.54 |    0.01 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |            |       |         |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 |  4.1340 ns | 0.0961 ns | 0.0803 ns |  4.1493 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |  5.8919 ns | 0.0235 ns | 0.0220 ns |  5.8839 ns |  1.43 |    0.03 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |            |       |         |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 |  4.8059 ns | 0.0237 ns | 0.0198 ns |  4.8051 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |           List_Value |   100 |  2.6583 ns | 0.0302 ns | 0.0268 ns |  2.6546 ns |  0.55 |    0.01 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |            |       |         |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 24.8057 ns | 0.2246 ns | 0.1991 ns | 24.7887 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 16.1590 ns | 0.1742 ns | 0.1629 ns | 16.1641 ns |  0.65 |    0.01 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |            |           |           |            |       |         |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |  4.1166 ns | 0.0343 ns | 0.0304 ns |  4.1228 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |  2.9000 ns | 0.0138 ns | 0.0129 ns |  2.8979 ns |  0.70 |    0.01 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |            |       |         |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |  5.0195 ns | 0.0448 ns | 0.0397 ns |  5.0170 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |       List_Reference |   100 |  3.0441 ns | 0.0630 ns | 0.0590 ns |  3.0476 ns |  0.61 |    0.01 |      - |     - |     - |         - |
