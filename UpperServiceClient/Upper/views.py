from django.http import HttpResponse
from django.http import JsonResponse
from django.shortcuts import render
from django.views.decorators.csrf import csrf_exempt
from zeep import Client
import json


def index(request):
    # client = Client('http://localhost:4444/UpperService?wsdl')
    # result = client.service.SpaceAfterPunctuationMark("Hello.friend.how are you?")
    #
    # return render(request, 'upper/index.html', [])
    # return HttpResponse('Qu')
    test = {"a": 'qwerty'}
    return render(request, 'upper/index.html', context=test)


@csrf_exempt
def some(request):
    receivedData = json.loads(request.body)

    # wcf service call
    # init client
    client = Client('http://localhost:4444/UpperService?wsdl')
    if receivedData['option'] == 'option1':
        result = client.service.Upper(receivedData['text'])
        print "Upper!"
        print "result: " + result
    if receivedData['option'] == 'option2':
        result = client.service.Lower(receivedData['text'])
        print "Lower!"
    if receivedData['option'] == 'option3':
        result = client.service.Capitalize(receivedData['text'])
        print "Capitalize!"
    if receivedData['option'] == 'option4':
        result = client.service.FirstLetterOfSentenceToUpper(receivedData['text'])
        print "First Letter Of Sentence To Upper!"
    if receivedData['option'] == 'option5':
        result = client.service.CountOfSymbols(receivedData['text'])
        print "Count Of Symbols"
    if receivedData['option'] == 'option6':
        result = client.service.SpaceAfterPunctuationMark(receivedData['text'])
        print "Space After Punctuation Mark"
    if receivedData['option'] == 'option7':
        result = client.service.Remove(receivedData['text'], receivedData['oldWord'])
        print "Remove"
    if receivedData['option'] == 'option8':
        result = client.service.Refactor(receivedData['text'], receivedData['oldWord'], receivedData['newWord'])
        print "Refactor"

    return JsonResponse({'formattedText': result})
