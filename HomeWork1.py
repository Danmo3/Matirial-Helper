#           Assingment 1
#Aoturs : Elad Yehuda , ID : 203142682
#        Dan Monsonego, ID : 313577595
#Campus : Beer Sheva

#Answer 1

"""
An xnor function that gets two boolean expressions and checks if they are equal 
then returns ture another false 
"""
def Xnor(a,b):
   return a==b

"""     Example      
print("Xnor(True,False)=>",Xnor(True,False))
print("Xnor(9>5,3<4)=>",Xnor(9>5,3<4))
print("Xnor(8<5,3==4)=>",Xnor(8<5,3==4))
print("Xnor(9<5,3<4)=>",Xnor(9<5,3<4))
print()

output:
Xnor(True,False)=>false
Xnor(9>5,3<4)=>true
Xnor(8<5,3==4)=>true
Xnor(9<5,3<4)=>false
"""

"""The absolute value function (useful function for all qwestions """
def Abs(num):
    if num<0:
        return num*-1
    return num


#Answer 2
"""
A digit function that receives a number and performs all kinds of calculations according to the digits, 
the number must be in a digit range of 1-5
"""
def Digits(n):

    """Helped function that calculates the number of digits of the number """
    def CountDigit(num):
        count = 0
        while num != 0:
            num//= 10
            count+=1
        return count


    count = CountDigit(n)

    """
    Check if the number of digits is in the range between 1-5 
    if above 5 we return an error message
    """
    if (count > 5):
        print("Error!")
        return

    """
    If the number of digits is 1 then we will keep 
    """
    sumDig = n % 10
    p = "one"

    """
    If the number of digits 2 or 3 we add to the digit we saved 
    in the variable sumDig (which keeps the last digit of each 
    number) the second or third digit respectively
    """
    if count == 2:
        sumDig += n // 10
        p = "two"

    elif count == 3:
        sumDig += n // 100
        p = "three"

    elif count > 3:
        sumDig = n // 100 % 10
        p = "five"
        if count == 4:
         sumDig += n // 10 % 10
         p = "four"


    print("The number received is: "+str(n)+" And it consists of " +p + " digit-",end="")

    #Check if the number is new odd or even
    if sumDig % 2 == 0:
        print("even(" + str(sumDig) + ")")

    else:
     print("odd(" + str(sumDig) + ")")

""" Examples 
print("Digits and even or odd")
Digits(91369)
Digits(8)
Digits(91)
Digits(731)
Digits(6504)
Digits(1234567)
print()

output:
Digits(91369)=>3 This is a middle digit in number and it is odd
Digits(8)=>8 This is the single digit in number and it is even
Digits(91)=>10 This is the result of a add of two digits and it is even
Digits(731)=>8 This is the result of a add of two digits the first and third and it is even
Digits(6504)=>5 This is the result of a add of two digits the middle and it is odd
Digits(1234567)=>Error
"""

#Answer 3
"""A function that checks whether all digits are even or odd"""
def GoodOrder(n):
        if n<0:
            return "error"
        isEven = (n % 10) % 2

        #do-while
        while True:
            n //= 10
            if n == 0 or (n % 10) % 2 != isEven:
             break

        return n == 0

""" Example  
print("Are all digits even or odd:")
print("12345=>",GoodOrder(12345))
print("264=>",GoodOrder(264))
print("1573=>",GoodOrder(1573))
print("831573=>",GoodOrder(831573))
print()


output:
GoodOrder(12345)=>false
GoodOrder(264)=>true
GoodOrder(1573)=>true
GoodOrder(831573)=>false
"""

#Answer 4
"""A function that prints the isosceles triangle with numbers in order"""
def Figure(num):
    if num < 1 or num > 10:
        return -1
    row = num
    col = row
    i = 0
    while i < row:
        j = 0
        print("\t\t", end="")
        while j < col:
            if i == row - 1:
                temp = Abs(row - j - 1) + 1
                print(temp,end="")

            elif j == (col - 1) or j == (row - 1 - i):
                print(i + 1,end="")
            else:
                print(" ",end="")

            j+=1
        col+=1
        print()
        i+=1

"""
Examples
print("An isosceles triangle made up of numbers in ascending order:")
Figure(9)
print()
'''
output:
Figure(9)
                1
		       2 2
		      3   3
		     4     4
		    5       5
		   6         6
		  7           7
		 8             8
		98765432123456789
"""

#Answer 5
""""
Weight function that receives a number and calculates with the help of two recursive functions 
the weight as the count of the number of digits with the large digit of the number.
"""
def Weight(n):

    """A recursive help function that calculates the amount of digits"""
    def CountDigit(n):
      if n == 0:
            return 0
      return CountDigit(n//10)+1

    """A recursive help function that returns the largest digit in the number"""
    def Digitest(n,k):
            if k < n % 10:
                k = n % 10

            if n < 10:
                return k

            return Digitest(n // 10, k)

    count=CountDigit(n)
    k = 0
    return Digitest(n, k)+count

""" Examples 
num=7145
num2=15
num3=351
print("Weight calculation:")
print("The weight for number {0} is:".format(num),(Weight(num)))
print("The weight for number {0} is:".format(num2),(Weight(num2)))
print("The weight for number {0} is:".format(num3),(Weight(num3)))
print()


output:
Digitest(num)+w=> The weight is: 11 because w=4 and Digitest is= 4
Digitest(num)+w=> The weight is: 7  because w=2 and Digitest is= 5
Digitest(num)+w=> The weight is: 8  because w=3 and Digitest is= 5
"""

#Answer 6
"""A recursive function that checks whether the number is prime"""
def IsPrimary(num):
    count=2
    def CheckPrime(num,count):
        if (num == 2 or count * count > num):
            return True

        if num < 2 or num % count == 0:
            return False

        count+=1
        return CheckPrime(num, count)

    return CheckPrime(num,count)
""" Examples 
print("Is number prime:")
print("23=> "+str(IsPrimary(23)))
print("21=> "+str(IsPrimary(21)))
print("4489=>",IsPrimary(4489))
print("89=>",IsPrimary(89))
print()

output:
IsPrimary(23)=>true
IsPrimary(21)=>false
IsPrimary(4489)=>false
IsPrimary(89)=>true
"""

#Answer 7

"""A recursive function that receives a number and produces a new number without the  '0' digit """
def Reduce(num):
    def Cut(num):
        if  num < 10:
            return num

        if (num % 10 == 0):
            return Cut(num // 10)

        return (Cut(num // 10) * 10 + num% 10)

    ans=Cut(Abs(num))
    if num<0:
        return ans*-1
    return ans

""" Examples 
print("Cut all digits 0:")
print("Before: -90093430 After:", Reduce(-90093430))
print("Before: 90001 After:", Reduce(90001))
print("Before: -160760 After:", Reduce(-160760))
print("Before: 1020034000 After:", Reduce(1020034000))
print()

output:
Reduce(-90093430)=>-99343
Reduce(90001)=>91 
Reduce(-160760)=>1676
Reduce(1020034000)=>1234
"""


#Answer 8
"""
The Pascal function is built on a base triangle. The function will return
the answer in as many different ways as possible Choose m objects from n objects
"""
def Pascal(n,k):
    """ n= rows , k = col """
    """Checking legality if the column> from the row we return 1- as a malfunction"""
    if n<k or n<0 or k<0:
        return -1
    """
    Necessary condition for stopping the recursive function, 
    if the column number is the same as the row number or the column is equal to 0 we return 1
    """
    if n==k or k==0:
        return 1

    """
    The magic line that returns the number in row n in the k column
    The function will call itself recursive and 
    connect the numbers that appear in k columns with the other n-k columns.
     """
    return Pascal(n-1,k)+Pascal(n-1,n-k)

"""  Examples  
print("Pascal's triangle:")
print("For (10,4)=>",Pascal(10,4))
print("For (0,0)=>",Pascal(0,0))
print("For (4,3)=>",Pascal(4,3))
print("For (9,8)=>",Pascal(9,8))
print()

output:
Pascal(10,4)=>210
Pascal(0,0)=>1
Pascal(4,3)=>4
"""