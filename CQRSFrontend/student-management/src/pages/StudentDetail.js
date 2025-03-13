import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getStudentById } from '../api/studentApi';

const StudentDetail = () => {
    const { id } = useParams();
    const [student, setStudent] = useState(null);

    useEffect(() => {
        async function fetchStudent() {
            const data = await getStudentById(id);
            setStudent(data);
        }
        fetchStudent();
    }, [id]);

    if (!student) return <p>Loading...</p>;

    return (
        <div>
            <h2>Chi Tiết Sinh Viên</h2>
            <p>Tên: {student.name}</p>
            <p>Email: {student.email}</p>
            <p>Địa chỉ: {student.address}</p>
            <p>Tuổi: {student.age}</p>
        </div>
    );
};

export default StudentDetail;