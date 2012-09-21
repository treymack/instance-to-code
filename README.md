Instance.ToCode
================

Unit testing is cool. Making up good test data is hard, especially if you have a complex object graph. Enter instance-to-code.

Run your program in VS, hit a breakpoint, and do a Quick Watch on the data you want to script to code. Then just change the Quick Watch expression to Instance.ToCode(yourObject). Copy the output and paste it into your test. Bam!