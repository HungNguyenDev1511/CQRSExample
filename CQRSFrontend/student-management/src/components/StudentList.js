import React, { useEffect, useState } from 'react';
import { getStudents } from '../api/studentApi';

const StudentList = () => {
    const [students, setStudents] = useState([]);

    useEffect(() => {
        async function fetchData() {
            const data = await getStudents();
            setStudents(data);
        }
        fetchData();
    }, []);

    return (
        <div>
            <h2>Danh sách Sinh Viên</h2>
            <ul>
                {students.map(student => (
                    <li key={student.id}>{student.name} - {student.email}</li>
                ))}
            </ul>
        </div>
    );
};

export default StudentList;