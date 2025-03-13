import React from 'react';
import { useParams } from 'react-router-dom';
import StudentForm from '../components/StudentForm';

const EditStudent = () => {
    const { id } = useParams();
    return (
        <div>
            <h2>Chỉnh Sửa Sinh Viên</h2>
            <StudentForm student={{ id }} onSave={() => window.location.reload()} />
        </div>
    );
};

export default EditStudent;