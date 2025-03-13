// src/api/studentApi.js
import axios from 'axios';

const API_URL = 'http://localhost:5000/api/student';

export const getStudents = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getStudentById = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const addStudent = async (student) => {
    const response = await axios.post(API_URL, student);
    return response.data;
};

export const updateStudent = async (student) => {
    const response = await axios.put(API_URL, student);
    return response.data;
};

export const deleteStudent = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};
