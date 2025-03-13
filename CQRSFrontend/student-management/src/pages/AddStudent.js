import React from 'react';
import StudentForm from '../components/StudentForm';

const AddStudent = () => {
    return (
        <div>
            <h2>Thêm Sinh Viên</h2>
            <StudentForm onSave={() => window.location.reload()} />
        </div>
    );
};

export default AddStudent;