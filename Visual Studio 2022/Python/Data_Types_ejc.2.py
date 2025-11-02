phrase = input("Say a sentence: ")
letras = []

for i in range(3):
    letra = input("Say a letter: ")
    letras.append(letra)

count1 = 0
count2 = 0
count3 = 0

for i in range(0, len(phrase)):
    if phrase[i] == letras[0]:
        count1 = count1 + 1
    if phrase[i] == letras[1]:
        count2 = count2 + 1
    if phrase[i] == letras[2]:
        count3 = count3 + 1

print("There are " + str(count1)+" "+letras[0]+ ", "+str(count2)+" "+letras[1]+" and "+str(count3)+ " "+ letras[2])