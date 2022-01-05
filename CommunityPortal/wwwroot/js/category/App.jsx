import React from 'react';
import Axios from 'axios';

const App = () => {

    React.useEffect(() => {
        Axios.get('Category/List').then(function (response) {
            console.log(response.data);
        });
    }, []);

    return (<h1>this is a sample</h1>);
}

export default App;