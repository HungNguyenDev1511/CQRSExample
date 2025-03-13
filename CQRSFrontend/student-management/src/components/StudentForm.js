import { addStudent, updateStudent } from '../api/studentApi';

const StudentForm = ({ student = {}, onSave }) => {
    const [formData, setFormData] = useState({
        name: student.name || '',
        email: student.email || '',
        address: student.address || '',
        age: student.age || ''
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (student.id) {
            await updateStudent({ ...formData, id: student.id });
        } else {
            await addStudent(formData);
        }
        onSave();
    };

    return (
        <form onSubmit={handleSubmit}>
            <input type="text" name="name" value={formData.name} onChange={handleChange} placeholder="Name" required />
            <input type="email" name="email" value={formData.email} onChange={handleChange} placeholder="Email" required />
            <input type="text" name="address" value={formData.address} onChange={handleChange} placeholder="Address" />
            <input type="number" name="age" value={formData.age} onChange={handleChange} placeholder="Age" />
            <button type="submit">{student.id ? 'Update' : 'Add'} Student</button>
        </form>
    );
};

export default StudentForm;