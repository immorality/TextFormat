import React from "react"

import Radio from "./Radio"

import axios from "axios"
import styled from 'styled-components';


const Button = styled.button`
  display: inline-block;
  color: black;
  font-weight: 700;
  text-decoration: none;
  user-select: none;
  padding: .5em 2em;
  outline: none;
  border: 2px solid;
  border-radius: 1px;
  transition: 0.2s;
  &:hover { background: DimGrey; }
  &:active { background: black; }
`;

const TextAreaEntry = styled.textarea`
  border: 1px solid black;
  background: white; //Gainsboro;
  color: #000000;
  padding: 10px;
  width: 500px;
  height: 250px;
  margin: 10px;
  resize: none;
`;

const TextEntry = styled.input`
  border: 1px solid black;
  background: white; //Gainsboro;
  color: #000000;
  padding: 5px;
  width: 150px;
  height: 20px;
  margin: 5px;
`;

const H1Style = styled.h2`
    margin: 10px;
    color: CornflowerBlue;  
`;


export default class TextArea extends React.Component {

    constructor(state) {
        super();
        this.state = {
            value: '',
            data: '',
            selectedOption: 'option1',
            showEntryRefactor: false,
            showEntryRemove: false,
            oldWord: '',
            newWord: ''
        };
        this.handleChange = this.handleChange.bind(this)
        this.handleOldChange = this.handleOldChange.bind(this)
        this.handleNewChange = this.handleNewChange.bind(this)
        this.handleOptionChange = this.handleOptionChange.bind(this)
    }

    click(text) {
        var dataSet = {
            'text': text,
            'option': this.state.selectedOption,
            'oldWord': this.state.oldWord,
            'newWord': this.state.newWord
        }
        axios.post('/someurl/', dataSet)
            .then((response) => {
                this.setState({data: response.data.formattedText})
            })

    }

    handleChange(event) {
        this.setState({value: event.target.value})
    }

    handleOldChange(event) {
        this.setState({oldWord: event.target.value})
    }

    handleNewChange(event) {
        this.setState({newWord: event.target.value})
    }

    handleOptionChange(event) {
        this.setState({selectedOption: event.target.value})
        if (event.target.value === 'option7') {
            this.setState({showEntryRemove: true})
            this.setState({showEntryRefactor: false})
        }
        else if (event.target.value === 'option8') {
            this.setState({showEntryRefactor: true})
            this.setState({showEntryRemove: false})
        }
        else {
            this.setState({showEntryRemove: false})
            this.setState({showEntryRefactor: false})
        }
    }

    handleOptionChange2(str) {
        console.log(str)
        this.setState({selectedOption: str})
    }

    render() {
        return (
            <div>
                <div className="uk-flex uk-flex-center">
                    <div className="uk-flex-column">
                        <H1Style>Type your text here:</H1Style>
                        <TextAreaEntry value={this.state.value} onChange={this.handleChange}></TextAreaEntry>
                    </div>
                    <div className="uk-flex-column">
                        <H1Style>Take your formatted text from here:</H1Style>
                        <TextAreaEntry value={this.state.data}></TextAreaEntry>
                    </div>
                </div>

                <div className="uk-flex uk-flex-center">
                    <div>
                        <div className="uk-flex">
                            <div className="uk-flex">
                                {this.state.showEntryRefactor && <h4>Old word:</h4>}
                                {this.state.showEntryRefactor &&
                                <TextEntry value={this.state.oldWord} onChange={this.handleOldChange}></TextEntry>}
                            </div>
                            <div className="uk-flex">
                                {this.state.showEntryRefactor && <h4>New word:</h4>}
                                {this.state.showEntryRefactor &&
                                <TextEntry value={this.state.newWord} onChange={this.handleNewChange}></TextEntry>}
                            </div>
                        </div>

                        <div className="uk-flex">
                            {this.state.showEntryRemove && <h4>Word:</h4>}
                            {this.state.showEntryRemove &&
                            <TextEntry value={this.state.oldWord} onChange={this.handleOldChange}></TextEntry>}
                        </div>

                        {/*<Radio newValue="option0" text="test" change={this.handleOptionChange2.bind(this)}/>*/}
                        <div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option1"
                                           checked={this.state.selectedOption === 'option1'}
                                           onChange={this.handleOptionChange}/>
                                    Upper
                                </label>
                            </div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option2"
                                           checked={this.state.selectedOption === 'option2'}
                                           onChange={this.handleOptionChange}/>
                                    Lower
                                </label>
                            </div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option3"
                                           checked={this.state.selectedOption === 'option3'}
                                           onChange={this.handleOptionChange}/>
                                    Capitalize
                                </label>
                            </div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option4"
                                           checked={this.state.selectedOption === 'option4'}
                                           onChange={this.handleOptionChange}/>
                                    First Letter Of Sentence To Upper
                                </label>
                            </div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option5"
                                           checked={this.state.selectedOption === 'option5'}
                                           onChange={this.handleOptionChange}/>
                                    Count Of Symbols
                                </label>
                            </div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option6"
                                           checked={this.state.selectedOption === 'option6'}
                                           onChange={this.handleOptionChange}/>
                                    Space After Punctuation Mark
                                </label>
                            </div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option7"
                                           checked={this.state.selectedOption === 'option7'}
                                           onChange={this.handleOptionChange}/>
                                    Remove
                                </label>
                            </div>
                            <div className="radio">
                                <label>
                                    <input type="radio" value="option8"
                                           checked={this.state.selectedOption === 'option8'}
                                           onChange={this.handleOptionChange}/>
                                    Refactor
                                </label>
                            </div>
                        </div >
                    </div>
                </div>
                <div className="uk-flex uk-flex-center">
                    <button className="uk-button uk-button-primary"
                            onClick={(text) => this.click(this.state.value)}>
                        Format
                    </button>
                </div>
            </div>
        )
    }
}
