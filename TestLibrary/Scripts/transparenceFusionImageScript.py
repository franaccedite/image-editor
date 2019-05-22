#!/usr/bin/python
import cv2
import numpy as np
from matplotlib import pyplot as plt
import sys

# print('Number of arguments:' + len(sys.argv) + 'arguments.')
print("--------------------------------")
print('Transparence fusion image method')
print("--------------------------------")

print('Argument List: ')
val = 0
for index, x in enumerate(sys.argv[::]):
    val += 1
    print(str(val) + ": " + sys.argv[index])

#c#
try:

	
	argFrontImageRoute = sys.argv[1]
	argBackImageRoute = sys.argv[2]
	print("front img route " + argFrontImageRoute)
	print("back img route " + argBackImageRoute)
	
except Exception as e:
	print('Failed trying to get each argument: '+ str(e))
print("---")


print('Proccessing cv2 imread images')
try:
	frontImage = cv2.imread(argFrontImageRoute)
	backImage = cv2.imread(argBackImageRoute)
	print('Imread executed successfully')
except Exception as e:
	print('Failed trying to read the images with imread: '+ str(e))

print("---")

#get sizes and calculate the avg of the two images

print('Getting the image size and channels')

try:
	frontHeight, frontWidth, frontChannels = frontImage.shape
	backHeight, backWidth, backChannels = backImage.shape
except Exception as e:
	print('Failed trying to get the shape of images: '+ str(e))

print('Calculating the size avg')

try:
	heightAvgSize = frontHeight + backHeight / 2
	widthAvgSize = frontWidth + backWidth / 2
	
	print("")
	
except Exception as e:
	print('Failed trying to calculate the sizes averages: '+ str(e))

# check if with diferent channels number dont generate error in the fusion


# do the resize to two images like: CvInvoke.Resize(backImage, resizedImageBack, new Size(668, 498));

print('Executing the resizing on images')

frontImgResized = cv2.resize(frontImage, (int(widthAvgSize), int(heightAvgSize))) 
backImgResized = cv2.resize(backImage, (int(widthAvgSize), int(heightAvgSize))) 


print("---")



# do addweith like: CvInvoke.addWeighted(resizedImageBack, 0.39, resizedImageMask, 0.61, 0.0, imgEdit);
print('Executing the addWeighted to get the new image')
try:
	newImage = cv2.addWeighted(frontImgResized, 0.39, backImgResized, 0.61, 0)
except Exception as e:
	print('Failed to execute addWeighted method. Message: ' + str(e))

	
print("---")

#saving the image
print('trying to save the new image')


newImagePath = r'C:\Users\LENOVO\source\repos\imageEditorProject\mvcImageEditor\wwwroot\uploads\created\aaa.png'

try:

	cv2.imwrite(newImagePath, newImage)
	#plt.savefig('C:\Users\LENOVO\source\repos\imageEditorProject\mvcImageEditor\wwwroot\uploads\created\aaa.png')
	print('Image saved successfully')
	print(newImagePath)

except Exception as e:
	print('Failed to save the image: '+ str(e))
	
	
print("")
print(newImagePath)

	
#return 'C:\Users\LENOVO\source\repos\imageEditorProject\mvcImageEditor\wwwroot\uploads\created\aaa.png'
	
#C:\Users\LENOVO\imageProjectEnv\Scripts\python C:\Users\LENOVO\source\repos\imageEditorProject\TestLibrary\Scripts\transparenceFusionImageScript.py C:\Users\LENOVO\Pictures\img1.PNG C:\Users\LENOVO\Pictures\Captura.PNG