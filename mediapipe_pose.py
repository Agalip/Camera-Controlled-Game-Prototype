# -*- coding: utf-8 -*-
"""
Ahmet Galip Sengun
06.2023

This code detects the body reference points and send their coordinates into specified port

"""

import cv2
import mediapipe as mp
import numpy as np
import socket


# Parameters
width, height = 1280, 720

mp_drawing =  mp.solutions.drawing_utils
mp_pose = mp.solutions.pose

cap = cv2.VideoCapture(0)

cap.set(3, width)
cap.set(4, height)


# Communication

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052) 


## Setup mediapipe instance
with mp_pose.Pose(min_detection_confidence=0.5, min_tracking_confidence=0.5) as pose:
    while cap.isOpened():
        ret, frame = cap.read()
        
        # Recolor image
        image = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        image.flags.writeable = False
        
        # Make detection
        results = pose.process(image)
        
        # Recolor back to BGR
        image.flags.writeable = True
        image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
        
        
        landmarks_list = []

        # Extract landmarks
        try:
            landmarks = results.pose_landmarks.landmark
            
            for landmark in landmarks:
                landmarks_list.extend([landmark.x, 1 - landmark.y, landmark.z])
            
        except:
            pass

        # print(landmarks[0])        


        # Send data
        sock.sendto(str.encode(str(landmarks_list)), serverAddressPort)

        # Render detections
        mp_drawing.draw_landmarks(image, results.pose_landmarks, mp_pose.POSE_CONNECTIONS)
        
        
        
        image  = cv2.resize(image, (0,0), None, 0.5, 0.5)
        cv2.imshow("Mediapipe Feed", image)

        if cv2.waitKey(10) & 0xFF == ord("q"):
            break

    cap.release()
    cv2.destroyAllWindows() 