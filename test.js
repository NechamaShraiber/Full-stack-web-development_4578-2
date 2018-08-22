function mul(n1,n2){
    console.log(n1*n2);
}

function mulOnlyNumbers(n1,n2){
    if(typeof(n1)!="number" ||typeof(n2)!="number")
    throw new Error("please send only 2 numbers");
    console.log(n1*n2);
}

mul(2,3);  //--> 6
mul(NaN,8);  //--> NaN 
mul(5);  //--> NaN 
mul("A","B");  //--> NaN 

mulOnlyNumbers(2,3);  //--> 6
mulOnlyNumbers(NaN,8);  //--> NaN 
mulOnlyNumbers(5);  //--> Error: please send only 2 numbers 
mulOnlyNumbers("A","B");  //--> Error: please send only 2 numbers 